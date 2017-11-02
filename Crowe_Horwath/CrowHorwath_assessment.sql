create database CH_HelloWorld
go

use CH_HelloWorld
go

create table [Message](
messageid int primary key identity(1,1) not null,
message nvarchar(max)
)

go

insert into Message
values('Hello World')

go

create proc GetHelloWorld 

as

select * from [Message]

go


