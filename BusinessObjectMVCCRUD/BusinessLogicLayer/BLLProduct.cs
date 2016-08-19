using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessLogicLayer.Entity;


namespace BusinessLogicLayer
{
   public class BLLProduct{

       public int CreateUser(ProductDetails pd) {

           SqlConnection con = new SqlConnection("Data Source=SWORNIM-PC; Integrated Security=True;Initial Catalog=SELFMVC;");
           string sql = "insert into tbl_Product values(@a,@b)";
           SqlCommand cmd = new SqlCommand(sql, con);
           cmd.Parameters.AddWithValue("@a", pd.ProductName);
           cmd.Parameters.AddWithValue("@b", pd.Price);
           con.Open();
           int i = cmd.ExecuteNonQuery();
           con.Close();


         
           return i;
       }
       public int Edit(ProductDetails pd) {
           SqlConnection con = new SqlConnection("Data Source=SWORNIM-PC; Integrated Security=True;Initial Catalog=SELFMVC;");
           string sql = "update tbl_Product set ProductName=@a, Price=@b where ProdictId=@c";
           SqlCommand cmd = new SqlCommand(sql, con);
           cmd.Parameters.AddWithValue("@a",pd.ProductName);
            cmd.Parameters.AddWithValue("@b",pd.Price);
            cmd.Parameters.AddWithValue("@c",pd.ProductId);
            con.Open();
           int i= cmd.ExecuteNonQuery();
            con.Close();
            return i;
       
       
       
       
       }
       public List<ProductDetails> GetAllUser() {
           List<ProductDetails> pdlst = new List<ProductDetails>();
           SqlConnection con = new SqlConnection("Data Source =SWORNIM-PC;Integrated Security=True; Initial Catalog=SELFMVC;");
           string sql = "select * from tbl_Product";
           SqlCommand cmd = new SqlCommand(sql, con);
           SqlDataReader dr = null;
           con.Open();
           dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               ProductDetails pd = new ProductDetails();
               pd.ProductId = (int)dr["ProdictId"];
               pd.ProductName = (string)dr["ProductName"];
               pd.Price = ((decimal)dr["Price"]).ToString() ;

               pdlst.Add(pd);
               
           }
           dr.Close();
           con.Close();


           return pdlst;
       }




       public List<ProductDetails> GetAllUserById(int id )
       {
           List<ProductDetails> pdlst = new List<ProductDetails>();
           SqlConnection con = new SqlConnection("Data Source =SWORNIM-PC;Integrated Security=True; Initial Catalog=SELFMVC;");
           string sql = "select * from tbl_Product where ProdictId=@id";
           SqlCommand cmd = new SqlCommand(sql, con);
           cmd.Parameters.AddWithValue("@id", id);
           SqlDataReader dr = null;
           con.Open();
           dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               ProductDetails pd = new ProductDetails();
               pd.ProductId = (int)dr["ProdictId"];
               pd.ProductName = (string)dr["ProductName"];
               pd.Price = ((decimal)dr["Price"]).ToString();

               pdlst.Add(pd);

           }
           dr.Close();
           con.Close();


           return pdlst;
       }
    }
}
