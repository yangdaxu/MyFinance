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
