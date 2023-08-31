
create procedure AddAddressBookDetail
(
@FirstName varchar(max),
@LastName varchar(max),
@Address varchar(max),
@City varchar(max),
@State varchar(max),
@Zip varchar(max),
@PhoneNumber varchar(max),
@Email varchar(max)
)
as
begin
insert Into address_book values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email)
End

drop table address_book;

select * from address_book;


create procedure EditContactDetails
(
@FirstName varchar(max),
@LastName varchar(max),
@Address varchar(max),
@City varchar(max),
@State varchar(max),
@Zip varchar(max),
@PhoneNumber varchar(max),
@Email varchar(max)
)
as
begin
update address_book set FirstName = @FirstName,LastNames = @LastName,Address=@Address,City=@City,State=@State,Zip=@Zip,PhoneNumber=@PhoneNumber,Email=@Email where FirstName = @FirstName;
End


create procedure DeleteContactDetails
(
@FirstName varchar(max),
@LastName varchar(max),
@Address varchar(max),
@City varchar(max),
@State varchar(max),
@Zip varchar(max),
@PhoneNumber varchar(max),
@Email varchar(max)
)
as
begin
delete address_book set FirstName = @FirstName,LastNames = @LastName,Address=@Address,City=@City,State=@State,Zip=@Zip,PhoneNumber=@PhoneNumber,Email=@Email where FirstName = @FirstName;
End


create procedure GroupByCity
as
begin
select * from address_book group by city;
End

