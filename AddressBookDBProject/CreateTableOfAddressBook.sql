create table AddressBook
( id int identity(1,1) not null,
  firstName varchar(100) ,
  lastName varchar(100),
  address varchar(200),
  city varchar(100),
  state varchar(100),
  zip int,
  phoneNumber varchar(300),
  email varchar(300)


)
select *from AddressBook