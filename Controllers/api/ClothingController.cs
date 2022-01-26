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
    public class ClothingController : ApiController
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(sportStoreDataContext.Clothings.ToList());
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
                return Ok(sportStoreDataContext.Clothings.First((clothing) => clothing.Id == id));
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
                sportStoreDataContext.Clothings.InsertOnSubmit(value);
                sportStoreDataContext.SubmitChanges();

                return Ok("Item of Clothing has been added successfully");
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
                Clothing clothingToEdit = sportStoreDataContext.Clothings.First((Clothing) => Clothing.Id == id);

                if (clothingToEdit != null)
                {
                    clothingToEdit.Type = value.Type;
                    clothingToEdit.Gender = value.Gender;
                    clothingToEdit.Company = value.Company;
                    clothingToEdit.Model = value.Model;
                    clothingToEdit.Price = value.Price;
                    clothingToEdit.Quantity = value.Quantity;
                    clothingToEdit.IsShort = value.IsShort;
                    clothingToEdit.IsDryfit = value.IsDryfit;
                    clothingToEdit.Image = value.Image;

                    sportStoreDataContext.SubmitChanges();

                    return Ok("Item of Clothing has been updated successfully");
                }
                return Ok("Sorry, No Item of Clothing was found");
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
                sportStoreDataContext.Clothings.DeleteOnSubmit(sportStoreDataContext.Clothings.First((clothing) => clothing.Id == id));
                sportStoreDataContext.SubmitChanges();

                return Ok("Item of Clothing has been deleted successfully");
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
