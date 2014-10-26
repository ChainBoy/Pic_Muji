using System;
using System.Collections.Generic;
using System.Text;

using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;

namespace TaoBao_Pic_Info
{
    public class ComputerCode
    {
        private string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        /// <summary>
        /// 获得CPU的序列号
        /// </summary>
        /// <returns></returns>
        private string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
        /// <summary>
        /// 组合字符串生成机器码
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public string getCom(string userName)
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string strMNum = md5(strNum + userName);
            return strMNum;
        }

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <param name="Com"></param>
        /// <returns></returns>
        public string getReg(string Com)
        {
            string reg = sha(Com);
            return reg;
        }

        /// <summary>
        /// md5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string md5(string str)
        {
            string result = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            return result;
        }

        /// <summary>
        /// sha 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string sha(string str)
        {
            string result = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
            return result;
        }
    }
}
