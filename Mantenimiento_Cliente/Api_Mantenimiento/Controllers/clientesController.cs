using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api_Mantenimiento.Models;
using System.Web.Http.Description;

namespace Api_Mantenimiento.Controllers
{
    public class clientesController : ApiController
    {
        MantenimientoEntities db = new MantenimientoEntities();

        // GET: api/clientes
        [HttpGet]
        [Route("api/GetClientes", Name = "GetClientes")]
        public List<listar_cliente_Result> GetClientes()
        {
            List<listar_cliente_Result> clientes = db.listar_cliente().ToList();
            return clientes;
        }

        [HttpGet]
        [Route("api/GetDepartamentos", Name = "GetDepartamentos")]
        public List<listar_departamento_Result> GetDepartamentos() {

            List<listar_departamento_Result> departamentos = db.listar_departamento().ToList();
            return departamentos;
        }

        // GET: api/clientes/5
        [HttpGet]
        [ResponseType(typeof(cliente))]
        [Route("api/GetClientesxid", Name = "GetClientesxid")]
        public IHttpActionResult GetClientesxid(int id)
        {
            List<listar_cliente_id_Result> clientesxid = db.listar_cliente_id(id).ToList();
            return Ok(clientesxid);
        }

        // POST: api/clientes
        [HttpPost]
        [ResponseType(typeof(cliente))]
        public IHttpActionResult PostClientes(cliente clientes)
        {
            db.crear_cliente(clientes.nombre,clientes.direccion,clientes.id_departamento);

            return CreatedAtRoute("DefaultApi", new { id = clientes.id_cliente }, clientes );
        }

        // PUT: api/clientes/5
        [HttpPut]
        [ResponseType(typeof(cliente))]
        public IHttpActionResult PutClientes(int id,cliente clientes)
        {
            db.modificar_cliente(clientes.id_cliente, clientes.nombre, clientes.direccion, clientes.id_departamento);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/clientes/5
        [HttpDelete]
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Delete(int id)
        {
            List<listar_cliente_id_Result> clientes = db.listar_cliente_id(id).ToList();
            return Ok();
        }
    }
}
