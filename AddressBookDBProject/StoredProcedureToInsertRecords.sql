Create procedure AddAddressBook1
(
@firstname varchar(150),
@lastname varchar(150),
@address varchar(150),
@city varchar(150),
@state varchar(150),
@zip int,
@phonenumber varchar(150),
@email varchar(150)

)
as
begin try
Insert into AddressBook values( @firstname,@lastname,@address,@city,@state,@zip,@phonenumber,@email)
End TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ERRORNumber,
ERROR_STATE() AS ERRORState,
ERROR_PROCEDURE() AS ERRORProcedure,
ERROR_LINE() AS ERRORLine,
ERROR_MESSAGE() AS ERRORMessage;
END CATCH
select *from AddressBook