﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dto;

namespace DogNKitty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController
    {
        private readonly ChatBusiness chatBusiness;

        private readonly string connection;

        public ChatController(IOptions<ConnectionStrings> config)
        {
            this.connection = config.Value.DbConnection;
            chatBusiness = new ChatBusiness(connection,null,null,null);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ChatDto>> Get(string title)
        {
            return chatBusiness.GetAllChat(title);
        }


        [HttpGet("{id}")]
        public ActionResult<ChatDto> GetById(int id)
        {
            return chatBusiness.GetChatById(id);
        }


        [HttpPost]
        public ActionResult<int> Post([FromBody] List<ChatDto> doacaos)
        {
            return chatBusiness.InsertChat(doacaos);
        }

        [HttpPost("message")]
        public ActionResult<int> PostMessage([FromBody] ChatMessagesDto message)
        {
            return chatBusiness.InsertChatMessage(message);
        }

        [HttpPut()]
        public ActionResult<int> Put([FromBody] ChatDto Chat)
        {
            return chatBusiness.UpdateChat(Chat);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            chatBusiness.DeleteChatById(id);
        }

        [HttpDelete("message/{id}")]
        public void DeleteMessage(int id)
        {
            chatBusiness.DeleteChatMessage(id);
        }
    }
}
