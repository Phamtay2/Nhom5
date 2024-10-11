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
                                    <th scope="col">Tên danh mục</th>
                                    <th scope="col">Ưu tiên</th>
                                    <th scope="col">Hiển thị</th>
                                    <th scope="col">Ghi chú</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="danhmuc in danhmucs" :key="danhmuc.id">
                                    <td>{{danhmuc.id}}</td>
                                    <td>{{danhmuc.tendm}}</td>
                                    <td>{{danhmuc.uutien}}</td>
                                    <td>{{danhmuc.hienthi}}</td>
                                    <td>{{danhmuc.ghichu}}</td>
                                    <td><button class="btn btn-primary btn-sm" @click="GetdanhmucById(danhmuc.id)">Cập nhật</button><button @click="Deletedanhmuc(danhmuc.id)" class="btn btn-secondary btn-sm">Delete Danh mục</button></td>
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
        <h2>Danh mục</h2>
        <div>
              <button type="button" class="btn btn-primary" @click="addNewdanhmuc()">Thêm mới</button>
              <button type="button" class="btn btn-secondary" onclick="closeaddModal()">Thoát</button>
          </div>
      </div>
      <div class="modal-bodyy">
          <form class="form-group row" enctype="multipart/form-data" id="myForm">
   
                      <label class="col-sm-2 col-form-label">Tên Danh mục:</label>
                      <div class="col-sm-10">
                      <textarea class="form-control" v-model="newdanhmuc.tendm" id="tendm" rows="1"></textarea>
                      </div>    
                      <label class="col-sm-2 col-form-label">ƯU tiên:</label>
                      <div class="col-sm-10">
                      <textarea class="form-control" v-model="newdanhmuc.uutien" id="uutien" rows="1"></textarea>
                      </div> 
                      <label class="col-sm-2 col-form-label">Hiển thị:</label>
                      <div class="col-sm-10">
                      <textarea class="form-control" v-model="newdanhmuc.hienthi" id="hienthi" rows="1"></textarea>
                      </div> 
                      <label class="col-sm-2 col-form-label">Ghi chú:</label>
                      <div class="col-sm-10">
                      <textarea class="form-control" v-model="newdanhmuc.ghichu" id="ghichu" rows="1"></textarea>
                      </div>                       
                                                 
        </form>
      </div>
      <div class="modal-footerr">
          <div></div>
          <div>
              <button type="button" class="btn btn-primary" @click="addNewdanhmuc()">Thêm mới</button>
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
              <button type="button" class="btn btn-primary" @click="Updatedanhmuc()">Cập nhật</button>
              <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
          </div>
      </div>
      <div class="modal-bodyy">
        <form class="form-group row" enctype="multipart/form-data" id="myForm">
            <label class="col-sm-2 col-form-label">Tên Danh mục:</label>
            <div class="col-sm-10">
              <textarea class="form-control" v-model="currentdm.tendm" id="tendm_update" rows="1"></textarea>
            </div>  
            <label class="col-sm-2 col-form-label">Ưu tiên:</label>
            <div class="col-sm-10">
              <textarea class="form-control" v-model="currentdm.uutien" id="uutien_update" rows="1"></textarea>
            </div> 
            <label class="col-sm-2 col-form-label">Hiển thị:</label>
            <div class="col-sm-10">
              <textarea class="form-control" v-model="currentdm.hienthi" id="hienthi_update" rows="1"></textarea>
            </div> 
            <label class="col-sm-2 col-form-label">Ghi chú:</label>
            <div class="col-sm-10">
              <textarea class="form-control" v-model="currentdm.ghichu" id="ghichu_update" rows="1"></textarea>
            </div> 
          
            <div style="display: none;">
              <textarea class="form-control" v-model="currentdm.id" id="id_update" rows="1"></textarea>
            </div>                        
          </form>
          
      </div>
      <div class="modal-footerr">
          <div></div>
          <div>
              <button type="button" class="btn btn-primary" @click="Updatedanhmuc()">Cập nhật</button>
              <button type="button" class="btn btn-secondary" onclick="closeupdateModal()">Thoát</button>
          </div>
      </div>
    </div>
  </div>
    
</template>

<script>
import axios from 'axios';

export default {
  name: 'DanhMucCom',
  data() {
    return {
      title: "Danh Muc",
      danhmucs: [],
      currentdm: {
        id: null,
        tendm: '',
        uutien: '',
        hienthi: '',
        ghichu: ''
      },
      newdanhmuc: {
        tendm: '',
        uutien: '',
        hienthi: '',
        ghichu: ''
      },
      showUpdateModal: false
    };
  },
  methods: {
    // Lấy tất cả các ghi chú
    async refreshNData() {
      try {
        const response = await axios.get("http://localhost:5105/api/Danhmuc/Getdanhmuc");
        this.danhmucs = response.data;
      } catch (error) {
        console.error("Error fetching danhmuc:", error);
      }
    },

    // Thêm mới ghi chú
    async addNewdanhmuc() {
      
      const formData = new FormData();
      formData.append("tendm", this.newdanhmuc.tendm);
      formData.append("uutien", this.newdanhmuc.uutien);
      formData.append("hienthi", this.newdanhmuc.hienthi);
      formData.append("ghichu", this.newdanhmuc.ghichu);

      try {
        const response = await axios.post("http://localhost:5105/api/Danhmuc/Adddanhmuc", formData);
        this.refreshNData();
        alert(response.data);
        this.newdanhmuc.tendm = '';
        this.newdanhmuc.uutien = '';
        this.newdanhmuc.hienthi = '';
        this.newdanhmuc.ghichu = '';
      } catch (error) {
        console.error("Error adding note:", error);
      }
    },

    // Xóa ghi chú
    async Deletedanhmuc(id) {
      try {
        const response = await axios.delete(`http://localhost:5105/api/Danhmuc/Deletedanhmuc?id=${id}`);
        this.refreshNData();
        alert(response.data);
      } catch (error) {
        console.error("Error deleting note:", error);
      }
    },

    // Lấy ghi chú theo ID
    async GetdanhmucById(id) {
      document.getElementById('modalUpdate').style.display = 'block';
      try {
        const response = await axios.get(`http://localhost:5105/api/Danhmuc/GetdanhmucById?id=${id}`);
        this.currentdm = response.data[0];
      } catch (error) {
        console.error("Error fetching note:", error);
      }
    },

    // Cập nhật ghi chú
    async Updatedanhmuc() {
      const formData = new FormData();
      formData.append("id", this.currentdm.id);
      formData.append("tendm", this.currentdm.tendm);
      formData.append("uutien", this.currentdm.uutien);
      formData.append("hienthi", this.currentdm.hienthi);
      formData.append("ghichu", this.currentdm.ghichu);

      try {
        const response = await axios.post("http://localhost:5105/api/Danhmuc/Updatedanhmuc", formData);
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



