using API_Alianza.Models;
using API_Alianza.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace API_Alianza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PadronController : Controller
    {
        private AlianzaDBContext AC;
        public PadronController(AlianzaDBContext AC)
        {
            this.AC = AC;
        }

        [HttpGet("GetCiudadano")]
        public OperationRequest GetCiudadono(string? Cedula)
        {
            OperationRequest or = new OperationRequest();
            PadronLog log = new PadronLog();
            validation va = new validation();
            try
            {

                //----------------------Permisos---------------------------------
                if (string.IsNullOrEmpty(Cedula))
                {
                    or.message = HttpResponseText.Null;
                    or.isSucess = false;
                    return or;

                }
                else if (Cedula != null)
                {
                    bool existCedula = va.ValidaCedula(Cedula);
                    if (!existCedula)
                    {
                        or.message = HttpResponseText.validation;
                        or.isSucess = false;
                    }
                    //----------------------Metodo--------------------------------
                    else
                    {
                        var db = AC.Padrons;
                        var respons = db.Where(x => x.Cedula == Cedula).ToList();
                        or.isSucess = true;
                        or.message = HttpResponseText.OK;
                        or.Data = respons.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                or.message = "Error:GetCiudadono" + ex;
                or.isSucess = false;
            }
            //----------------------Log---------------------------------
            log.Message = or.message;
            log.Method = "GetCiudadono";
            log.Params = "{" + $"Cedula: '{Cedula}'" + "}";
            log.Fecha = DateTime.Now;
            log.Status = or.isSucess;
            AC.PadronLogs.Add(log);
            AC.SaveChanges();
            return or;
        }

        [HttpPost("PostCiudadano")]
        public OperationRequest PostCiudadano(string? Cedula, string? direccion, string? telefono)
        {
            OperationRequest or = new OperationRequest();
            PadronLog log = new PadronLog();
            validation va = new validation();
            bool existCedula = AC.PadronIngresos.Where(x => x.Cedula == Cedula).Count().Equals(0);
            try
            {
                //----------------------Permisos---------------------------------
                if (string.IsNullOrEmpty(Cedula))
                {
                    or.message = HttpResponseText.Null;
                    or.isSucess = false;
                    return or;
                }
                if (!existCedula)
                {
                    or.message = HttpResponseText.NoResult;
                    or.isSucess = false;
                }
                //----------------------Metodo--------------------------------
                else
                {
                        var respons = from x in AC.Padrons
                                      where x.Cedula == Cedula
                                      select new PadronIngreso()
                                      {
                                          Cedula = x.Cedula,
                                          Nombres = x.Nombres,
                                          Apellido1 = x.Apellido1,
                                          Apellido2 = x.Apellido2,
                                          FechaNacimiento = x.FechaNacimiento,
                                          LugarNacimiento = x.LugarNacimiento,
                                          Idcategoria = x.Idcategoria,
                                          IdSexo = x.IdSexo,
                                          IdEstadoCivil = x.IdEstadoCivil,
                                          IdOcupacion = x.IdOcupacion,
                                          Idnacionalidad = x.Idnacionalidad,
                                          Idmunicipio = x.Idmunicipio,
                                          IdSectorParaje = x.IdSectorParaje,
                                          Idcolegio = x.Idcolegio,
                                          IdcausaCancelacion = x.IdcausaCancelacion,
                                          Idestatus = x.Idestatus,
                                          EstatusCedulaAzul = x.EstatusCedulaAzul,
                                          CedulaAnterior = x.CedulaAnterior,
                                          MunCed = x.MunCed,
                                          SeqCed = x.SeqCed,
                                          VerCed = x.VerCed,
                                          Direccion = direccion,
                                          Telefono = telefono,
                                      };
                        or.isSucess = true;
                        or.message = HttpResponseText.OK;
                        or.Data = respons.ToList();
                        AC.PadronIngresos.AddRange(respons);
                        AC.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                or.message = "Error:PostCiudadano" + ex;
                or.isSucess = false;
            }
            //----------------------Log---------------------------------
            log.Message = or.message;
            log.Method = "PostCiudadano";
            log.Params = "{" + $"Cedula: '{Cedula}', Codigo : '{direccion}', telefono : '{telefono}'" + "}";
            log.Fecha = DateTime.Now;
            log.Status = or.isSucess;
            AC.PadronLogs.Add(log);
            AC.SaveChanges();
            return or;
        }



    }
}
