using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PortalMiniso.Entity
{
    public class Repositorio
    {
        private PlantillasEntities3  plantillasEntities;

        public Repositorio()
        {
            plantillasEntities = new PlantillasEntities3();
        }

        public List<INV2> getInv2()
        {
            List<INV2> lista = plantillasEntities.INV2.ToList();

            return lista;
        }


        public List<CUENTAS> obtCuentas()
        {
            List<CUENTAS> lista = plantillasEntities.CUENTAS.ToList();

            return lista;
        }

        
        public int obtContadorFormaPagoVpm(string tenderId)
        {
            int count = plantillasEntities.VPM.Count(t => t.DoCNum == tenderId);

            return count;
        }
        public int obtContadorFormaPagoRct(string tenderId)
        {
            int count = plantillasEntities.RCT.Count(t => t.DoCNum == tenderId);

            return count;
        }


        public string guardar(INV2 iNV2)
        {
            string str = string.Empty;
            try
            {
                plantillasEntities.INV2.AddOrUpdate(iNV2);
                plantillasEntities.SaveChanges();
                str = "ok";
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }

            return str;
        }

        public string guardarOinv(OINV oinv)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.OINV.AddOrUpdate(oinv);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
                respuesta = oinv.DocNum;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return respuesta.ToString();
        }

        public string guardarInv2(INV2 inv2)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.INV2.AddOrUpdate(inv2);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
                
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }
        public string guardarInv(INV inv)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.INV.AddOrUpdate(inv);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
                
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }

        public string guardarOrin(ORIN orin)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.ORIN.AddOrUpdate(orin);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }

        public string guardarRin(RIN rin)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.RIN.AddOrUpdate(rin);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }

        public string guardarRct(RCT rct)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.RCT.AddOrUpdate(rct);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }

        public string guardarVpm(VPM vpm)
        {
            string mensaje = string.Empty;
            int respuesta = 0;
            try
            {
                plantillasEntities.VPM.AddOrUpdate(vpm);
                respuesta = plantillasEntities.SaveChanges();
                mensaje = "ok";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return respuesta.ToString();
        }
    }
}