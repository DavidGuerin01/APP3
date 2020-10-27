using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("manette/xbox")]
        public IActionResult PostXbox(Comment cmt)
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

            return Ok(System.IO.File.ReadAllText("/tmp/xbox"));
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
