---------------Veiw---------------------------
create procedure GetAddressBookTable1
(
@id int
)
as 
begin TRY 
select * from AddressBook
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