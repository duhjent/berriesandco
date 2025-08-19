<template>
    <v-form v-model="valid" @submit.prevent @submit="submit">
        <v-container>
            <v-row>
                <v-col>
                    <v-text-field v-model="word" label="Word" :rules="wordRules" required></v-text-field>
                </v-col>
                <v-col>
                    <v-btn type="submit" :disabled="!valid">Submit</v-btn>
                </v-col>
            </v-row>
        </v-container>
    </v-form>

    <v-card v-if="results && results.length != 0">
        <v-list :items="results" disabled></v-list>
    </v-card>
    <v-card v-if="results && results.length == 0">
        No results
    </v-card>

    <v-alert v-if="apiError" :text="apiError"></v-alert>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { VAlert, VCard, VList, VRow, VCol, VForm, VContainer, VTextField, VBtn } from 'vuetify/components';

const word = ref('');
const valid = ref(false);

const results = ref<string[]>();

const apiError = ref();

const wordRules = [
    (value: string) => {
        if (value) { return true; }

        return 'Word is required';
    },
    (value: string) => {
        if (value.length == 5) { return true; }

        return 'Word length needs to be exactly 5';
    }
]

async function submit() {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    try {
        const resp = await fetch(`${baseUrl}/anagram`,
            {
                method: 'POST',
                body: JSON.stringify({ word: word.value }),
                headers: { 'Content-Type': 'application/json' }
            });
        results.value = await resp.json() as string[];
        apiError.value = null;
    } catch(error) {
        apiError.value = error;
    }
}
</script>
