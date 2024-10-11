<template>
    <HeaderComponent/>
  <SanPhamCom/>
  </template>
  
  <script>
  // @ is an alias to /src
  import HeaderComponent from '@/components/Header.vue'
  import SanPhamCom from '../components/SanPhamCom.vue';
  
  export default {
  name: 'SanPham',
  components: {
    HeaderComponent,
    SanPhamCom
  }
  }
  </script>
  