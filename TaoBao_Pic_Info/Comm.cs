using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    }
}
