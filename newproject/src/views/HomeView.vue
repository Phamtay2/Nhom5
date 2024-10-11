<template>
  <HeaderComponent/>
<IndexCom/>

</template>

<script>
// @ is an alias to /src
import HeaderComponent from '@/components/Header.vue'
import IndexCom from '@/components/IndexCom.vue'

export default {
name: 'HomeView',
components: {
  HeaderComponent,
  IndexCom
}
}
</script>
