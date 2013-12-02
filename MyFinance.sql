--´´½¨±í
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tKindOfCost]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tKindOfCost]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tAccount]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tAccount]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tBusiness]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tBusiness]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tTransfer]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tTransfer]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tPerson]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tPerson]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tTransferStatus]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tTransferStatus]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tFlagDefine]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tFlagDefine]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = object_id(N'[dbo].[tBalance]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1)
	DROP TABLE [dbo].[tBalance]
GO

create table tKindOfCost
(ID int primary key identity(1,1),Name nvarchar(50) not null default(''),ParentID int not null)
create table tAccount
(ID int primary key identity(1,1),Name nvarchar(50) not null default(''),TypeFlag tinyint not null)
create table tBusiness
(ID int primary key identity(1,1),Direction tinyint not null,KindOfCoustID int not null,AccountID int not null,
Date smalldatetime not null ,Amount money not null,Note nvarchar(200))
create table tTransfer
(ID int primary key identity(1,1),OutAccountID int not null ,InAccount int not null ,Amount money not null,Note nvarchar(200) not null default(''))
create table tPerson
(ID int primary key identity(1,1),Name nvarchar(50) not null)
create table tTransferStatus
(ID int primary key identity(1,1),TransferID int not null, StatusFlag tinyint not null,PersonID int not null)
create table tFlagDefine
(ID int primary key identity(1,1),TableName varchar(50) not null,FieldName varchar(50) not null ,FlagValue tinyint not null)
create table tBalance
(ID int primary key identity(1,1),AccountID int not null,datetime smalldatetime not null,Amount money not null)
