USE [master]
GO
/****** Object:  Database [Quanlybanhang]    Script Date: 11/10/2024 10:34:29 SA ******/
CREATE DATABASE [Quanlybanhang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quanlybanhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ANTHONYPC\MSSQL\DATA\Quanlybanhang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quanlybanhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ANTHONYPC\MSSQL\DATA\Quanlybanhang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Quanlybanhang] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quanlybanhang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quanlybanhang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quanlybanhang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quanlybanhang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quanlybanhang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quanlybanhang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quanlybanhang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quanlybanhang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quanlybanhang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quanlybanhang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quanlybanhang] SET  MULTI_USER 
GO
ALTER DATABASE [Quanlybanhang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quanlybanhang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quanlybanhang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quanlybanhang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quanlybanhang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quanlybanhang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Quanlybanhang] SET QUERY_STORE = ON
GO
ALTER DATABASE [Quanlybanhang] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Quanlybanhang]
GO
/****** Object:  Table [dbo].[danhmuc]    Script Date: 11/10/2024 10:34:29 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhmuc](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[tendm] [nvarchar](max) NULL,
	[uutien] [int] NULL,
	[hienthi] [int] NULL,
	[ghichu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 11/10/2024 10:34:29 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[masp] [nchar](50) NULL,
	[tensp] [nvarchar](max) NULL,
	[danhmuc] [nvarchar](max) NULL,
	[gianhap] [int] NULL,
	[giaban] [int] NULL,
	[giakm] [int] NULL,
	[soluong] [int] NULL,
	[hienthi] [int] NULL,
	[thoigian] [datetime] NULL,
	[mota] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taikhoan]    Script Date: 11/10/2024 10:34:29 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](max) NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[phanquyen] [nvarchar](max) NULL,
	[thoigian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[danhmuc] ON 

INSERT [dbo].[danhmuc] ([id], [tendm], [uutien], [hienthi], [ghichu]) VALUES (1, N'Nghiêm gay', 1, 2, N'is Real')
INSERT [dbo].[danhmuc] ([id], [tendm], [uutien], [hienthi], [ghichu]) VALUES (2, N'Akshan', 1, 1, N'E')
SET IDENTITY_INSERT [dbo].[danhmuc] OFF
GO
SET IDENTITY_INSERT [dbo].[sanpham] ON 

INSERT [dbo].[sanpham] ([id], [masp], [tensp], [danhmuc], [gianhap], [giaban], [giakm], [soluong], [hienthi], [thoigian], [mota]) VALUES (1, N'1                                                 ', N'aa', N'bb', 1100, 1000, 50, 1, 1, CAST(N'2024-05-19T00:00:00.000' AS DateTime), N'bb')
INSERT [dbo].[sanpham] ([id], [masp], [tensp], [danhmuc], [gianhap], [giaban], [giakm], [soluong], [hienthi], [thoigian], [mota]) VALUES (2, N'mm                                                ', N'aa', N's', 3, 2, 1, 1, 1, CAST(N'2024-10-05T00:00:00.000' AS DateTime), N'aaa')
INSERT [dbo].[sanpham] ([id], [masp], [tensp], [danhmuc], [gianhap], [giaban], [giakm], [soluong], [hienthi], [thoigian], [mota]) VALUES (3, N'mm                                                ', N'aa', N's', 3, 2, 1, 1, 1, CAST(N'2024-10-05T00:00:00.000' AS DateTime), N'aaa')
INSERT [dbo].[sanpham] ([id], [masp], [tensp], [danhmuc], [gianhap], [giaban], [giakm], [soluong], [hienthi], [thoigian], [mota]) VALUES (4, N'1b                                                ', N'cccc', N'b', 4, 2, 1, 1, 1, CAST(N'2024-07-05T00:00:00.000' AS DateTime), N'cc')
SET IDENTITY_INSERT [dbo].[sanpham] OFF
GO
SET IDENTITY_INSERT [dbo].[taikhoan] ON 

INSERT [dbo].[taikhoan] ([id], [ten], [username], [password], [email], [phanquyen], [thoigian]) VALUES (1, N'Tây', N'tuananheadar', N'11111111', N'phamtay357@gmail.com', N'1', CAST(N'2024-10-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[taikhoan] OFF
GO
USE [master]
GO
ALTER DATABASE [Quanlybanhang] SET  READ_WRITE 
GO
