﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using web_app_performance.model;

namespace web_app_performance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetUsuario()
        {
            String connectionString = "Server=localhost;Database=sys;User=root;Password=123";
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            string query = "select Id, Nome, Email from usuarios;";
            var usuarios = await connection.QueryAsync<Usuario>(query);

            return Ok(usuarios);
        }

    }
}
