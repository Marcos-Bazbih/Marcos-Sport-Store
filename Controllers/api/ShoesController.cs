using Marcos_Sport_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marcos_Sport_Store.Controllers.api
{
    public class ShoesController : ApiController
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(sportStoreDataContext.Shoes.ToList());
            }
            catch (SqlException SqlEx)
            {
                return BadRequest(SqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(sportStoreDataContext.Shoes.First((shoe) => shoe.Id == id));
            }
            catch (SqlException SqlEx)
            {
                return BadRequest(SqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public IHttpActionResult Post([FromBody] Shoe value)
        {
            try
            {
                sportStoreDataContext.Shoes.InsertOnSubmit(value);
                sportStoreDataContext.SubmitChanges();

                return Ok("Shoe has been added successfully");
            }
            catch (SqlException SqlEx)
            {
                return BadRequest(SqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public IHttpActionResult Put(int id, [FromBody] Shoe value)
        {
            try
            {
                Shoe shoeToEdit = sportStoreDataContext.Shoes.First((shoe) => shoe.Id == id);

                if (shoeToEdit != null)
                {
                    shoeToEdit.Type = value.Type;
                    shoeToEdit.Company = value.Company;
                    shoeToEdit.Model = value.Model;
                    shoeToEdit.Price = value.Price;
                    shoeToEdit.Quantity = value.Quantity;
                    shoeToEdit.InSale = value.InSale;
                    shoeToEdit.Image = value.Image;

                    sportStoreDataContext.SubmitChanges();

                    return Ok("Shoe has been updated successfully");
                }
                return Ok("Sorry, No shoe was found");
            }
            catch (SqlException SqlEx)
            {
                return BadRequest(SqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public IHttpActionResult Delete(int id)
        {
            try
            {
                sportStoreDataContext.Shoes.DeleteOnSubmit(sportStoreDataContext.Shoes.First((shoe) => shoe.Id == id));
                sportStoreDataContext.SubmitChanges();

                return Ok("Shoe has been deleted successfully");
            }
            catch (SqlException SqlEx)
            {
                return BadRequest(SqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
