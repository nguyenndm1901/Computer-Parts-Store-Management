use [master]
GO

create database DBCPDM
GO

use DBCPSM
GO

create table StaffLogIn 
(
	id char(20) not null,
	pass char(20) not null
)

create table KhachHang
(	
	maKH int identity(1,1) primary key not null,
	ngayMua date not null,
	maHD varchar(10) not null,
	tenKH nvarchar(50) not null,
	sdt char(15) not null
)

create table SanPham
(
	id int identity(1,1) primary key not null,
	maSP varchar(10) not null,
	tenSP nvarchar(50) not null,
	giaTien int not null,
	dvt nchar(10) not null,
	thoiGianBH int not null,
)

create table NhanVien
(
	id int identity(1,1) primary key not null,
	maNV varchar(5) not null,
	tenNV nvarchar(50) not null,
	doanhThu int not null
)

create table HoaDon
(
	maHD varchar(10) primary key not null,
	ngayXuatHD date not null,
	tongTien int not null,
	tenKH nvarchar(50) not null,
	tenNV nvarchar(50) not null,
)	

create table ThongKe
(	
	id int identity(1,1) primary key not null,
	ngay date not null,
	maHD varchar(10) NULL,
	maSP varchar(10) NULL,
	tenSP nvarchar(50) NULL,
	dvt nchar(10) NULL,
	soLuong int NULL,
	giaTien int NULL,
	thanhTien int NULL
)

INSERT INTO [dbo].[StaffLogIn] ([id],[pass]) VALUES('hamvui9910','hamvui9920')
INSERT INTO [dbo].[StaffLogIn] ([id],[pass]) VALUES('nguyenndm1901','12345612')
INSERT INTO [dbo].[StaffLogIn] ([id],[pass]) VALUES('testid','testpass')

SET IDENTITY_INSERT [dbo].[NhanVien] ON
INSERT INTO [dbo].[NhanVien] ([id],[maNV],[tenNV],[doanhThu]) VALUES(1,'NV001',N'Trần Đức Phú',0)
INSERT INTO [dbo].[NhanVien] ([id],[maNV],[tenNV],[doanhThu]) VALUES(2,'NV002',N'Trương Ngọc Minh',0)
INSERT INTO [dbo].[NhanVien] ([id],[maNV],[tenNV],[doanhThu]) VALUES(3,'NV003',N'Huỳnh Phương Thảo',0)
INSERT INTO [dbo].[NhanVien] ([id],[maNV],[tenNV],[doanhThu]) VALUES(4,'NV004',N'Cù Huy Chiến',0)
INSERT INTO [dbo].[NhanVien] ([id],[maNV],[tenNV],[doanhThu]) VALUES(5,'NV005',N'Huỳnh Hoàng Thiên Tài',0)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF

SET IDENTITY_INSERT [dbo].[SanPham] ON
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (1,'SP001','Asus Vivobook X407MA',7200000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (2,'SP002','Acer Aspire A315-53',7490000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (3,'SP003','Asus Vivobook X507MA',6390000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (4,'SP004','Acer Aspire E5-476',9990000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (5,'SP005','Acer Aspire A315-54K',9999000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (6,'SP006','Lenovo Ideapad 330S',11000000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (7,'SP007','Lenovo V330 15IKB',11390000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (8,'SP008','HP Pavilion 15 CS3010TU',13490000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (9,'SP009','Dell Inspiron 5593',13990000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (10,'SP010','Acer Aspire A515-53G',14790000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (11,'SP011','AMD Athlon 200GE 3.2GHz',1460000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (12,'SP012','AMD Ryzen 3 2200G 3.5 GHz',2450000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (13,'SP013','AMD Ryzen 3 3200G 3.6GHz',2590000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (14,'SP014','AMD Ryzen 5 2400G 3.6 GHz',3950000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (15,'SP015','AMD Ryzen 5 3400G 3.7GHz',4090000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (16,'SP016','AMD Ryzen 5 3600 3.6GHz',5390000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (17,'SP017','AMD Ryzen 5 3600x 3.8GHz',6490000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (18,'SP018','AMD Ryzen 7 3700x 3.6GHz',8690000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (19,'SP019','AMD Ryzen 7 3800x 3.9GHz',10290000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (20,'SP020','AMD Ryzen 9 3900x 3.8GHz',13090000,N'cái',36)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (21,'SP021','Dell E2216H 22" TN',2370000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (22,'SP022','LG 22MK430H-B 22" IPS',2550000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (23,'SP023','Asus VP228NE 22" TN',2650000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (24,'SP024','Viewsonic VA2456-H 24" IPS',2790000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (25,'SP025','ASUS VA24EHE 24" IPS',3290000,N'cái',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (26,'SP026','RAM Geil 4GB 2666',550000,N'bộ',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (27,'SP027','RAM Corsair 4GB 2666',770000,N'bộ',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (28,'SP028','RAM Crucial 8GB 2400',850000,N'bộ',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (29,'SP029','GSKILL TRIDENT 8GB 3000',1000000,N'bộ',24)
INSERT INTO [dbo].[SanPham] ([id],[maSP],[tenSP],[giaTien],[dvt],[thoiGianBH]) VALUES (30,'SP030','RAM APACER 8GB 3200',1490000,N'bộ',24)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
