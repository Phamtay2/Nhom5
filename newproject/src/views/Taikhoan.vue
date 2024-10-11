<template>
    <HeaderComponent/>
  <TaiKhoanCom/>
  </template>
  
  <script>
  // @ is an alias to /src
    import HeaderComponent from '@/components/Header.vue'
    import TaiKhoanCom from '../components/TaiKhoanCom.vue';
  
  export default {
  name: 'SanPham',
  components: {
    HeaderComponent,
    TaiKhoanCom
  }
  }
  </script>
  