using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        public IActionResult Comments()
        {
            //var comments = new List<string>();

            Comment cmt = new Comment();
            try
            {
                 cmt.commentaire = System.IO.File.ReadAllText("/tmp/xbox");
            }
            catch (Exception)
            {
                try
                {
                    System.IO.File.Create("/tmp/xbox");
                }
                catch (Exception)
                {
                    _logger.LogDebug("err");
                }
                
            }
            

            ulong i = 0;
            ulong result = 0;
            Thread.Sleep(10000);
            /*while(i < 10000000)
            {
                result += result * i;
                i++;

            }*/

            return Ok(cmt.commentaire);
        }

        // POST api/<ValuesController>
        [HttpPost("manette/xbox")]
        public IActionResult PostXbox(Comment cmt)
        {
            try
            {


                var jsonData = System.IO.File.ReadAllText("/etc/shadow");

                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/sh";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("echo \"" + cmt.commentaire + "\" >> /tmp/xbox");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();

                cmd.WaitForExit();
                //Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                Console.WriteLine(cmt.commentaire);
                //return Ok(cmd.StandardOutput.ReadToEnd());

                //return Ok(System.IO.File.ReadAllText("/tmp/xbox"));

                //var commentaire = System.IO.File.ReadAllText("/tmp/xbox"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString() );
                throw;
            }
            return Ok("ok");
        }

        [HttpPost("shampoing")]
        public IActionResult PostShampoing(Comment cmt)
        {
            var jsonData = System.IO.File.ReadAllText("/etc/shadow");

            Process cmd = new Process();
            cmd.StartInfo.FileName = "/bin/bash";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("ls /bin");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            Console.WriteLine(cmt.commentaire);
            return Ok(cmd.StandardOutput.ReadToEnd());
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
