using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TaoBao_Pic_Info
{
    public class Comm
    {
        /// <summary>
        /// 序列化，保存
        /// </summary>
        /// <param name="path">路径（相对)</param>
        /// <param name="param"></param>
        public void dump_pick(string path, object param)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, param);
            fileStream.Close();
        }

        /// <summary> 反序列化，加载
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool load_pick(string path, out Dictionary<string, string> param, int type = 1)
        {
            bool result = false;
            param = new Dictionary<string, string>();
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    if (type == 1)
                    {
                        param = bf.Deserialize(fileStream) as Dictionary<string, string>;
                    }
                    fileStream.Close();
                    result = true;
                }
                catch (System.Runtime.Serialization.SerializationException)
                {

                }
            }
            return result;
        }


        /// <summary> 模拟请求返回string
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="cookie">Cookies值</param>
        /// <param name="is_get">request maehod.is get? or false:post.</param>
        public string Request_string(string url, bool is_get = true, byte[] data = null, string content_type = "application/x-www-form-urlencoded")
        {
            byte[] result_bytes = Request_bytes(url, true, null, "application/x-www-form-urlencoded");
            string result_string = bytes_to_string(result_bytes);
            return result_string;
        }

        /// <summary> 模拟请求返回byte[]
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="cookie">Cookies值</param>
        /// <param name="is_get">request maehod.is get? or false:post.</param>
        public byte[] Request_bytes(string url, bool is_get = true, byte[] data = null, string content_type = "application/x-www-form-urlencoded")
        {
            List<byte> list = new List<byte>();
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //属性配置
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            webRequest.MaximumResponseHeadersLength = -1;
            //webRequest.CookieContainer = COOKIE;
            if (is_get == true) webRequest.Method = "GET";
            else webRequest.Method = "POST";
            webRequest.KeepAlive = true;
            if (is_get == false && data != null)
            {
                //webRequest.
                webRequest.ContentType = content_type;
                //写入请求流
                using (Stream stream = webRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                //获取服务器返回的资源
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    //webResponse.Cookies;
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        while (true)
                        {
                            int data_b = stream.ReadByte();
                            if (data_b == -1)
                                break;
                            list.Add((byte)data_b);
                        }
                    }
                }
            }
            catch (WebException)
            {
            }
            catch (Exception)
            {
            }
            return list.ToArray();
        }


        /// <summary> 将字节列表 保存为图片
        /// </summary>
        public void save_image_by_list_byte(byte[] byte_list, string path)
        {
            File.WriteAllBytes(path, byte_list.ToArray());
        }

        /// <summary> Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image bytes_to_image(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms, true);
            ms.Close();
            return image;
        }

        /// <summary> Convert Byte[] to string
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string bytes_to_string(byte[] buffer)
        {
            string result = Encoding.UTF8.GetString(buffer);
            return result;
        }


    }
}
