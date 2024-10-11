import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import DanhMuc from '../views/Danhmuc.vue'
import SanPham from '../views/Sanpham.vue'
import TaiKhoan from '../views/Taikhoan.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/danh-muc',
    name: 'danhmuc',
    component: DanhMuc
  },
  {
    path: '/san-pham',
    name: 'sanpham',
    component: SanPham
  },
  {
    path: '/tai-khoan',
    name: 'taikhoan',
    component: TaiKhoan
  }
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
