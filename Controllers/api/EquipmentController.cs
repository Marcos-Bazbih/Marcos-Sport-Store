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
    public class EquipmentController : ApiController
    {
        static string connectionString = "Data Source=LENOVO-MARCOS;Initial Catalog=SportStoreDb;Integrated Security=True;Pooling=False";
        SportStoreDataContext sportStoreDataContext = new SportStoreDataContext(connectionString);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(sportStoreDataContext.Equipments.ToList());
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
                return Ok(sportStoreDataContext.Equipments.First((item) => item.Id == id));
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



        public IHttpActionResult Post([FromBody] Equipment value)
        {
            try
            {
                sportStoreDataContext.Equipments.InsertOnSubmit(value);
                sportStoreDataContext.SubmitChanges();

                return Ok("Item of Equipment has been added successfully");
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



        public IHttpActionResult Put(int id, [FromBody] Equipment value)
        {
            try
            {
                Equipment equipmentToEdit = sportStoreDataContext.Equipments.First((item) => item.Id == id);

                if (equipmentToEdit != null)
                {
                    equipmentToEdit.SportType = value.SportType;
                    equipmentToEdit.ProductName = value.ProductName;
                    equipmentToEdit.Company = value.Company;
                    equipmentToEdit.Price = value.Price;
                    equipmentToEdit.Quantity = value.Quantity;
                    equipmentToEdit.TeamId = value.TeamId;
                    equipmentToEdit.Image = value.Image;

                    sportStoreDataContext.SubmitChanges();

                    return Ok("Item of Equipment has been updated successfully");
                }
                return Ok("Sorry, No Item of Equipment was found");
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
                sportStoreDataContext.Equipments.DeleteOnSubmit(sportStoreDataContext.Equipments.First((item) => item.Id == id));
                sportStoreDataContext.SubmitChanges();

                return Ok("Item of Equipment has been deleted successfully");
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
