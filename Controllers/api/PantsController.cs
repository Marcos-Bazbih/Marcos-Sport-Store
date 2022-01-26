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
    public class PantsController : ApiController
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(sportStoreDataContext.Clothings.Where((item) => item.Type == "Pants").ToList());
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
                return Ok(sportStoreDataContext.Clothings.Where((item) => item.Type == "Pants").First((item) => item.Id == id));
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
                if (value.Type == "Pants")
                {
                    sportStoreDataContext.Clothings.InsertOnSubmit(value);
                    sportStoreDataContext.SubmitChanges();
                    return Ok("Pants has been added successfully");
                }
                return Ok("This item is not pants");
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
                Clothing pantsToEdit = sportStoreDataContext.Clothings.Where((item) => item.Type == "Pants").First((item) => item.Id == id);

                if (pantsToEdit != null)
                {
                    pantsToEdit.Type = value.Type;
                    pantsToEdit.Gender = value.Gender;
                    pantsToEdit.Company = value.Company;
                    pantsToEdit.Model = value.Model;
                    pantsToEdit.Price = value.Price;
                    pantsToEdit.Quantity = value.Quantity;
                    pantsToEdit.IsShort = value.IsShort;
                    pantsToEdit.IsDryfit = value.IsDryfit;
                    pantsToEdit.Image = value.Image;

                    sportStoreDataContext.SubmitChanges();

                    return Ok("Pants has been updated successfully");
                }
                return Ok("Sorry, No Pants was found");
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
                sportStoreDataContext.Clothings.DeleteOnSubmit(sportStoreDataContext.Clothings.Where((item) => item.Type == "Pants").First((item) => item.Id == id));
                sportStoreDataContext.SubmitChanges();

                return Ok("Pants has been deleted successfully");
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
