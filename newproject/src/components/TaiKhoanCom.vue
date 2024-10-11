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
                                      <th scope="col">Tên</th>
                                      <th scope="col">Username</th>
                                      <th scope="col">Password</th>
                                      <th scope="col">Email</th>
                                      <th scope="col">Phân quyền</th>
                                      <th scope="col">Thời gian</th>
                                      
                                      <th></th>
                                  </tr>
                              </thead>
                              <tbody>
                                  <tr v-for="Taikhoan in Taikhoans" :key="Taikhoan.id">
                                      <td>{{Taikhoan.id}}</td>
                                      <td>{{Taikhoan.ten}}</td>
                                      <td>{{Taikhoan.username}}</td>
                                      <td>{{Taikhoan.password}}</td>
                                      <td>{{Taikhoan.email}}</td>
                                      <td>{{Taikhoan.phanquyen}}</td>
                                      <td>{{Taikhoan.thoigian}}</td>
                                      <td><button class="btn btn-primary btn-sm" @click="GetTaikhoanById(Taikhoan.id)">Cập nhật</button><button @click="DeleteTaikhoan(Taikhoan.id)" class="btn btn-secondary btn-sm">Delete Sản phẩm</button></td>
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
          <h2>Tài Khoản</h2>
          <div>
                <button type="button" class="btn btn-primary" @click="addNewTaikhoan()">Thêm mới</button>
                <button type="button" class="btn btn-secondary" onclick="closeaddModal()">Thoát</button>
            </div>
        </div>
        <div class="modal-bodyy">
            <form class="form-group row" enctype="multipart/form-data" id="myForm">
                        <label class="col-sm-2 col-form-label">Tên:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.ten" id="ten" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Username:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.username" id="username" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Password:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.password" id="password" rows="1"></textarea>
                        </div>
                        <label class="col-sm-2 col-form-label">Email:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.email" id="email" rows="1"></textarea>
                        </div>    
                        <label class="col-sm-2 col-form-label">Phân quyền:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.phanquyen" id="phanquyen" rows="1"></textarea>
                        </div> 
                        <label class="col-sm-2 col-form-label">Thời gian:</label>
                        <div class="col-sm-10">
                        <textarea class="form-control" v-model="newTaikhoan.thoigian" id="thoigian" rows="1"></textarea>
                        </div> 
                                                   
          </form>
        </div>
        <div class="modal-footerr">
            <div></div>
            <div>
                <button type="button" class="btn btn-primary" @click="addNewTaikhoan()">Thêm mới</button>
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
                <button type="button" class="btn btn-primary" @click="UpdateTaikhoan()">Cập nhật</button>
                <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
            </div>
        </div>
        <div class="modal-bodyy">
          <form class="form-group row" enctype="multipart/form-data" id="myForm">
              <label class="col-sm-2 col-form-label">Tên:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.ten" id="ten_update" rows="1"></textarea>
              </div>  
              <label class="col-sm-2 col-form-label">Username:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.username" id="username_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Password:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.password" id="password_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Email:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.email" id="email_update" rows="1"></textarea>
              </div> 
              <label class="col-sm-2 col-form-label">Phân Quyền:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.phanquyen" id="phanquyen_update" rows="1"></textarea>
              </div>  
              <label class="col-sm-2 col-form-label">Thời gian:</label>
              <div class="col-sm-10">
                <textarea class="form-control" v-model="currenttk.thoigian" id="thoigian_update" rows="1"></textarea>
              </div> 
            
              <div style="display: none;">
                <textarea class="form-control" v-model="currenttk.id" id="id_update" rows="1"></textarea>
              </div>                        
            </form>
            
        </div>
        <div class="modal-footerr">
            <div></div>
            <div>
                <button type="button" class="btn btn-primary" @click="UpdateTaikhoan()">Cập nhật</button>
                <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
            </div>
        </div>
      </div>
    </div>
      
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'TaikhoanCom',
    data() {
      return {
        title: "Tai Khoan",
        Taikhoans: [],
        currenttk: {
          id: null,
          ten: '',
          username: '',
          password: '',
          email: '',
          phanquyen: '',
          thoigian: '',
        },
        newTaikhoan: {
          ten: '',
          username: '',
          password: '',
          email: '',
          phanquyen: '',
          thoigian: '',
        },
        showUpdateModal: false
      };
    },
    methods: {
      // Lấy tất cả các ghi chú
      async refreshNData() {
        try {
          const response = await axios.get("http://localhost:5105/api/Taikhoan/GetTaikhoan");
          this.Taikhoans = response.data;
        } catch (error) {
          console.error("Error fetching Taikhoan:", error);
        }
      },
  
      // Thêm mới ghi chú
      async addNewTaikhoan() {
        
        const formData = new FormData();
        formData.append("ten", this.newTaikhoan.ten);
        formData.append("username", this.newTaikhoan.username);
        formData.append("password", this.newTaikhoan.password);
        formData.append("email", this.newTaikhoan.email);
        formData.append("phanquyen", this.newTaikhoan.phanquyen);
        formData.append("thoigian", this.newTaikhoan.thoigian);
        try {
          const response = await axios.post("http://localhost:5105/api/Taikhoan/AddTaikhoan", formData);
          this.refreshNData();
          alert(response.data);
          this.newTaikhoan.ten = '';
          this.newTaikhoan.username = '';
          this.newTaikhoan.password = '';
          this.newTaikhoan.email = '';
          this.newTaikhoan.phanquyen = '';
          this.newTaikhoan.thoigian = '';
        } catch (error) {
          console.error("Error adding note:", error);
        }
      },
  
      // Xóa ghi chú
      async DeleteTaikhoan(id) {
        try {
          const response = await axios.delete(`http://localhost:5105/api/Taikhoan/DeleteTaikhoan?id=${id}`);
          this.refreshNData();
          alert(response.data);
        } catch (error) {
          console.error("Error deleting note:", error);
        }
      },
  
      // Lấy ghi chú theo ID
      async GetTaikhoanById(id) {
        document.getElementById('modalUpdate').style.display = 'block';
        try {
          const response = await axios.get(`http://localhost:5105/api/Taikhoan/GetTaikhoanById?id=${id}`);
          this.currenttk = response.data[0];
        } catch (error) {
          console.error("Error fetching note:", error);
        }
      },
  
      // Cập nhật ghi chú
      async UpdateTaikhoan() {
        const formData = new FormData();
        formData.append("id", this.currenttk.id);
        formData.append("ten", this.currenttk.ten);
        formData.append("username", this.currenttk.username);
        formData.append("password", this.currenttk.password);
        formData.append("email", this.currenttk.email);
        formData.append("phanquyen", this.currenttk.phanquyen);
        formData.append("thoigian", this.currenttk.thoigian);
        
  
  
        try {
          const response = await axios.post("http://localhost:5105/api/Taikhoan/UpdateTaikhoan", formData);
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
  
  
  
  