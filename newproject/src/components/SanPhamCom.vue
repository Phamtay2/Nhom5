<template>
    <!-- Dashboard -->
  <div class="d-flex flex-column flex-lg-row h-lg-full bg-surface-secondary content">
      <!-- Vertical Navbar -->
      <nav class="navbar show navbar-vertical h-lg-screen navbar-expand-lg px-0 py-3 navbar-light bg-white border-bottom border-bottom-lg-0 border-end-lg" id="navbarVertical">
          <div class="container-fluid">
              <!-- Toggler -->
              <button class="navbar-toggler ms-n2" type="button" data-bs-toggle="collapse" data-bs-target="#sidebarCollapse" aria-controls="sidebarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="sidebarCollapse">
                  <!-- Navigation -->
                  <ul class="navbar-nav nav1">
                      <li class="nav-item">
                          <a class="nav-link" href="/">
                              <i class="bi bi-house"></i> Trang chủ
                          </a>
                      </li>
                      <li class="nav-item">
                          <a class="nav-link" href="danh-muc">
                              <i class="bi bi-folder"></i> Danh mục
                          </a>
                      </li>
                      <li class="nav-item">
                          <a class="nav-link" href="san-pham">
                              <i class="bi bi-box"></i> Sản phẩm
                          </a>
                      </li>
                      <li class="nav-item">
                          <a class="nav-link" href="tai-khoan">
                              <i class="bi bi-person-square"></i> Tài khoản
                          </a>
                      </li>
                      
                  </ul>
                  <!-- Divider -->
                  <hr class="navbar-divider my-5 opacity-20">
              </div>
          </div>
      </nav>
      <!-- Main content -->
      <div class="h-screen flex-grow-1 overflow-y-lg-auto">
          <!-- Main -->
          <main class="py-6 bg-surface-secondary">
              <div class="container-fluid">
  
                  <div class="card shadow border-0 mb-7">
                      <div class="row">
                          <div class="col-sm-6 col-12 text-sm-start">
                              <div class="card-header">
                                  <h5 class="mb-0">Applications</h5>
                              </div>
                          </div>
                          <div class="col-sm-6 col-12 text-sm-end">
                              <div class="mx-n1" style="padding: 20px;">
                                  <a href="#" class="btn d-inline-flex btn-sm btn-neutral border-base mx-1">
                                      <span class=" pe-2">
                                          <i class="bi bi-pencil"></i>
                                      </span>
                                      <span>Edit</span>
                                  </a>
                                  <a href="#" class="btn d-inline-flex btn-sm btn-danger mx-1" onclick="showaddModal()">
                                      <span class=" pe-2">
                                          <i class="bi bi-plus"></i>
                                      </span>
                                      <span>Create</span>
                                  </a>
                              </div>
                          </div>
                      </div>
                      
                      <div class="table-responsive">
                          <table class="table table-hover table-nowrap">
                              <thead class="thead-light">
                                  <tr>
                                      <th scope="col">Id</th>
                                      <th scope="col">Mã sản phẩm</th>
                                      <th scope="col">Tên sản phẩm</th>
                                      <th scope="col">Danh mục</th>
                                      <th scope="col">Giá nhập</th>
                                      <th scope="col">Giá bán</th>
                                      <th scope="col">Giá km</th>
                                      <th scope="col">Số lượng</th>
                                      <th scope="col">Hiển thị</th>
                                      <th scope="col">Thời gian</th>
                                      <th scope="col">Mô tả</th>
                                      
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  <tr v-for="sanpham in sanphams" :key="sanpham.id">
                                      <td>{{sanpham.id}}</td>
                                      <td>{{sanpham.masp}}</td>
                                      <td>{{sanpham.tensp}}</td>
                                      <td>{{sanpham.danhmuc}}</td>
                                      <td>{{sanpham.gianhap}}</td>
                                      <td>{{sanpham.giaban}}</td>
                                      <td>{{sanpham.giakm}}</td>
                                      <td>{{sanpham.soluong}}</td>
                                      <td>{{sanpham.hienthi}}</td>
                                      <td>{{sanpham.thoigian}}</td>
                                      <td>{{sanpham.mota}}</td>
                                      <td><button class="btn btn-primary btn-sm" @click="GetsanphamById(sanpham.id)">Cập nhật</button><button @click="Deletesanpham(sanpham.id)" class="btn btn-secondary btn-sm">Delete Sản phẩm</button></td>
                                  </tr>
                                  
                              </tbody>
                          </table>
                      </div>
                      <div class="card-footer border-0 py-5">
                          <span class="text-muted text-sm">Showing 10 items out of 250 results found</span>
                      </div>
                  </div>
  
                  </div>
          </main>
      </div>
  </div>
  <div class="modal-overlay" id="modalAdd">
      <div class="modaladd">
        <div class="modal-headerr">
          <h2>Sản phẩm</h2>
          <div>
                <button type="button" class="btn btn-primary" @click="addNewsanpham()">Thêm mới</button>
                <button type="button" class="btn btn-secondary" onclick="closeaddModal()">Thoát</button>
            </div>
        </div>
        <div class="modal-bodyy">
            <form class="form-group row" enctype="multipart/form-data" id="myForm">
                        <label class="col-sm-2 col-form-label">Mã sp:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.masp" id="masp" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Tên sp:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.tensp" id="tensp" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Danh mục:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.danhmuc" id="danhmuc" rows="1"></textarea>
                        </div>
                        <label class="col-sm-2 col-form-label">Giá nhập:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.gianhap" id="gianhap" rows="1"></textarea>
                        </div>    
                        <label class="col-sm-2 col-form-label">Giá bán:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.giaban" id="giaban" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Giá khuyến mãi:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.giakm" id="giakm" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Số lượng:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.soluong" id="soluong" rows="1"></textarea>
                        </div>
                        <label class="col-sm-2 col-form-label">Hiển thị:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.hienthi" id="hienthi" rows="1"></textarea>
                        </div>     
                        <label class="col-sm-2 col-form-label">Thời gian:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.thoigian" id="thoigian" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Mô tả:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newsanpham.mota" id="mota" rows="1"></textarea>
                        </div>                                   
                                                   
          </form>
        </div>
        <div class="modal-footerr">
            <div></div>
            <div>
                <button type="button" class="btn btn-primary" @click="addNewsanpham()">Thêm mới</button>
                <button type="button" class="btn btn-secondary" onclick="closeaddModal()">Thoát</button>
            </div>
        </div>
      </div>
    </div>
  
    <div class="modal-overlay" id="modalUpdate">
      <div class="modaladd">
        <div class="modal-headerr">
          <h2>Cập nhật danh mục</h2>
          <div>
                <button type="button" class="btn btn-primary" @click="Updatesanpham()">Cập nhật</button>
                <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
            </div>
        </div>
        <div class="modal-bodyy">
          <form class="form-group row" enctype="multipart/form-data" id="myForm">
              <label class="col-sm-2 col-form-label">Mã sp:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.masp" id="masp_update" rows="1"></textarea>
              </div>  
              <label class="col-sm-2 col-form-label">Tên sản phẩm:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.tensp" id="tensp_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Danh mục:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.danhmuc" id="danhmuc_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Giá nhập:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.gianhap" id="gianhap_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Giá bán:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.giaban" id="giaban_update" rows="1"></textarea>
              </div>  
              <label class="col-sm-2 col-form-label">Giá km:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.giakm" id="giakm_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Số lượng:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.soluong" id="soluong_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Hiển thị:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.hienthi" id="hienthi_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Thời gian:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.thoigian" id="thoigian_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Mô tả:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currentsp.mota" id="mota_update" rows="1"></textarea>
              </div> 
            
              <div style="display: none;">
                <textarea class="form-control" v-model="currentsp.id" id="id_update" rows="1"></textarea>
              </div>                        
            </form>
            
        </div>
        <div class="modal-footerr">
            <div></div>
            <div>
                <button type="button" class="btn btn-primary" @click="Updatesanpham()">Cập nhật</button>
                <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
            </div>
        </div>
      </div>
    </div>
      
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'SanPhamCom',
    data() {
      return {
        title: "San Pham",
        sanphams: [],
        currentsp: {
          id: null,
          masp: '',
          tensp: '',
          danhmuc: '',
          gianhap: '',
          giaban: '',
          giakm: '',
          soluong: '',
          hienthi: '',
          thoigian: '',
          mota: ''
        },
        newsanpham: {
          masp: '',
          tensp: '',
          danhmuc: '',
          gianhap: '',
          giaban: '',
          giakm: '',
          soluong: '',
          hienthi: '',
          thoigian: '',
          mota: ''
        },
        showUpdateModal: false
      };
    },
    methods: {
      // Lấy tất cả các ghi chú
      async refreshNData() {
        try {
          const response = await axios.get("http://localhost:5105/api/sanpham/Getsanpham");
          this.sanphams = response.data;
        } catch (error) {
          console.error("Error fetching sanpham:", error);
        }
      },
  
      // Thêm mới ghi chú
      async addNewsanpham() {
        
        const formData = new FormData();
        formData.append("masp", this.newsanpham.masp);
        formData.append("tensp", this.newsanpham.tensp);
        formData.append("danhmuc", this.newsanpham.danhmuc);
        formData.append("gianhap", this.newsanpham.gianhap);
        formData.append("giaban", this.newsanpham.giaban);
        formData.append("giakm", this.newsanpham.giakm);
        formData.append("soluong", this.newsanpham.soluong);
        formData.append("hienthi", this.newsanpham.hienthi);
        formData.append("thoigian", this.newsanpham.thoigian);
        formData.append("mota", this.newsanpham.mota);
  
        try {
          const response = await axios.post("http://localhost:5105/api/sanpham/Addsanpham", formData);
          this.refreshNData();
          alert(response.data);
          this.newsanpham.masp = '';
          this.newsanpham.tensp = '';
          this.newsanpham.danhmuc = '';
          this.newsanpham.gianhap = '';
          this.newsanpham.giaban = '';
          this.newsanpham.giakm = '';
          this.newsanpham.soluong = '';
          this.newsanpham.hienthi = '';
          this.newsanpham.thoigian = '';
          this.newsanpham.mota = '';
        } catch (error) {
          console.error("Error adding note:", error);
        }
      },
  
      // Xóa ghi chú
      async Deletesanpham(id) {
        try {
          const response = await axios.delete(`http://localhost:5105/api/sanpham/Deletesanpham?id=${id}`);
          this.refreshNData();
          alert(response.data);
        } catch (error) {
          console.error("Error deleting note:", error);
        }
      },
  
      // Lấy ghi chú theo ID
      async GetsanphamById(id) {
        document.getElementById('modalUpdate').style.display = 'block';
        try {
          const response = await axios.get(`http://localhost:5105/api/sanpham/GetsanphamById?id=${id}`);
          this.currentsp = response.data[0];
        } catch (error) {
          console.error("Error fetching note:", error);
        }
      },
  
      // Cập nhật ghi chú
      async Updatesanpham() {
        const formData = new FormData();
        formData.append("id", this.currentsp.id);
        formData.append("masp", this.currentsp.masp);
        formData.append("tensp", this.currentsp.tensp);
        formData.append("danhmuc", this.currentsp.danhmuc);
        formData.append("gianhap", this.currentsp.gianhap);
        formData.append("giaban", this.currentsp.giaban);
        formData.append("giakm", this.currentsp.giakm);
        formData.append("soluong", this.currentsp.soluong);
        formData.append("hienthi", this.currentsp.hienthi);
        formData.append("thoigian", this.currentsp.thoigian);
        formData.append("mota", this.currentsp.mota);
        
  
  
        try {
          const response = await axios.post("http://localhost:5105/api/sanpham/Updatesanpham", formData);
          this.refreshNData();
          alert(response.data);
          document.getElementById('modalUpdate').style.display = 'none';
        } catch (error) {
          console.error("Error updating note:", error);
        }
      },
  
  
    },
    mounted() {
      this.refreshNData();
    }
  };
  </script>
  
  
  
  