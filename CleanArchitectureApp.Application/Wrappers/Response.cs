using CleanArchitectureApp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Wrappers
{
    public class Response
    {
        public Response()
        {

        }
        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }
    public class Response<T> : Response
    {
        
        public Response()
        {

        }
        public Response(T data, string message = null) : base(message) 
        {            
            Data = data;
        }       
        
        public T Data { get; set; }
    }
}
