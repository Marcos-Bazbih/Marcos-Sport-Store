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
    public class ShirtsController : ApiController
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(sportStoreDataContext.Clothings.Where((item) => item.Type == "Shirts").ToList());
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
                return Ok(sportStoreDataContext.Clothings.Where((item) => item.Type == "Shirts").First((item) => item.Id == id));
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



        public IHttpActionResult Post([FromBody] Clothing value)
        {
            try
            {
                if (value.Type == "Shirts")
                {
                    sportStoreDataContext.Clothings.InsertOnSubmit(value);
                    sportStoreDataContext.SubmitChanges();
                    return Ok("Shirt has been added successfully");
                }
                return Ok("This item is not a shirt");
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



        public IHttpActionResult Put(int id, [FromBody] Clothing value)
        {
            try
            {
                Clothing shirtToEdit = sportStoreDataContext.Clothings.Where((item) => item.Type == "Shirts").First((item) => item.Id == id);

                if (shirtToEdit != null)
                {
                    shirtToEdit.Type = value.Type;
                    shirtToEdit.Gender = value.Gender;
                    shirtToEdit.Company = value.Company;
                    shirtToEdit.Model = value.Model;
                    shirtToEdit.Price = value.Price;
                    shirtToEdit.Quantity = value.Quantity;
                    shirtToEdit.IsShort = value.IsShort;
                    shirtToEdit.IsDryfit = value.IsDryfit;
                    shirtToEdit.Image = value.Image;

                    sportStoreDataContext.SubmitChanges();

                    return Ok("Shirt has been updated successfully");
                }
                return Ok("Sorry, No Shirt was found");
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
                sportStoreDataContext.Clothings.DeleteOnSubmit(sportStoreDataContext.Clothings.Where((item) => item.Type == "Shirts").First((item) => item.Id == id));
                sportStoreDataContext.SubmitChanges();

                return Ok("Shirt has been deleted successfully");
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
