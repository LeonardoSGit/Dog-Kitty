﻿using System;
using System.Collections.Generic;
using Dto;
using Entity;
namespace Business.Mappers
{
    public class UsuarioMapper
    {
            public UsuarioDto EntityToDto(Usuario usuario)
        {
            if (usuario != null)
            {
                return new UsuarioDto()
                {
                    Id = usuario.Id,
                    Contato = usuario.Contato,
                    Email = usuario.Email,
                    Endereco = usuario.Endereco,
                    IsAdmin = usuario.IsAdmin,
                    Nome = usuario.Nome
                };
            }return null;
            }
            public List<UsuarioDto> ListEntityToListDto(IEnumerable<Usuario> usuarios)
            {
                List<UsuarioDto> dtos = new List<UsuarioDto>();
                foreach (var usuario in usuarios)
                {
                    dtos.Add(EntityToDto(usuario));

                }
                return dtos;
            }

            public Usuario DtoToEntity(UsuarioDto usuario)
            {
            if (usuario != null)
            {
                return new Usuario()
                {
                    Id = usuario.Id,
                    Contato = usuario.Contato,
                    Email = usuario.Email,
                    Endereco = usuario.Endereco,
                    IsAdmin = usuario.IsAdmin,
                    Nome = usuario.Nome
                };
            }return null;
            }

            public List<Usuario> ListDtoToListEntity(IEnumerable<UsuarioDto> usuarios)
            {
                List<Usuario> dtos = new List<Usuario>();
                foreach (var Usuario in usuarios)
                {
                    dtos.Add(DtoToEntity(Usuario));

                }
                return dtos;
            }
    }
}
