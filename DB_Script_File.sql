use ProductQuotationDB
--select * from sys.tables
select * From UserDetail
select * From Product
select * From Quotation
select * From QuotationDetails
select * from AspNetUsers

Create table Product 
(
	ProductID int identity(1,1) Primary Key,
	ProductName varchar(100) not null,
	ProductDescription varchar(1000) not null,
	ProductQuantity int not null,
	ProductDuration datetime not null,
	ActiveProduct bit,
	CreatedBy int not null,
	CreatedDate datetime not null,
	ModifyBy int not null,
	ModifyDate datetime not null,
)
Go 
Create table UserDetail
(
	UserID int identity(1,1) Unique,
	AspNetUsersID nvarchar(128) primary key,
	UserName varchar(100) not null,
	EmailID varchar(100) not null,
	ContactNo varchar(20) null,
	CreatedDate datetime not null
)
Go
Create table Quotation
(
	QuotationID int identity(1,1) primary key,
	ProductID int not null,
	RequestedQuantity int not null,
	RequestUserID int not null,
	RequestDate datetime not null
)
Go

Create table QuotationDetails
(
	QuotationDetailsID int identity(1,1),
	QuotationID int not null,
	ApproveQuantity int not null,
	ApproveUserID int not null,
	ApproveDate datetime not null,
	Remark varchar(200)
)