<template>
  <HeaderComponent/>
<DanhMucCom/>
</template>

<script>
// @ is an alias to /src
import HeaderComponent from '@/components/Header.vue'
import DanhMucCom from '@/components/DanhMucCom.vue'

export default {
name: 'DanhMuc',
components: {
  HeaderComponent,
  DanhMucCom
}
}
</script>
