namespace Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO
{
    public class BD
    {
        private static User02Context user02Context = new User02Context();
        public static User02Context GetInstance() 
        { 
            if(user02Context==null)
                user02Context = new User02Context();
            return user02Context; 
        }
    }
}
