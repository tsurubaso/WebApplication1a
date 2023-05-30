using System.Data;
using System.Data.SqlClient;





namespace WebApplication1a.Models
{
    public class Dal
    {
        public Response Registration(Registration registration, SqlConnection connection) 
        
        {
        Response response = new Response();
        SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name, Email, Password, PhoneNo, IsActive, IsApproved) VALUES('"+registration.Name+"','"+registration.Email+"','"+registration.Password+"','"+registration.PhoneNo+"',1,0)", connection);
        connection.Open();
        int i=cmd.ExecuteNonQuery();
        connection.Close();
        if (i > 0)
            {
                response.Status

            }


            return response;
        
        
        }



    }
}
