import './assets/main.css'

import { createApp } from 'vue'
import { createVuetify } from 'vuetify'
import { VAlert, VCard, VList, VForm, VContainer, VRow, VCol, VTextField, VBtn } from 'vuetify/components'
import App from './App.vue'

const vuetify = createVuetify({
    components: [VAlert, VCard, VList, VForm, VContainer, VRow, VCol, VTextField, VBtn],
    directives: []
})

createApp(App).use(vuetify).mount('#app')
