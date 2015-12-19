using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Esk
{
    public struct eskbone
    {
        public string Name;
        public int MatrixAddress;
        public Matrix4x4 transformData;
        public int parentIndex;
    }

    public struct Matrix4x4
    {
        public float m00;
        public float m01;
        public float m02;
        public float m03;

        public float m10;
        public float m11;
        public float m12;
        public float m13;

        public float m20;
        public float m21;
        public float m22;
        public float m23;

        public float m30;
        public float m31;
        public float m32;
        public float m33;
    }

    class esk
    {
        public eskbone[] Bones;
        string path;

        public void ReadEsk(string filepath)
        {
            path = filepath;
            using (BinaryReader eskfile = new BinaryReader(File.Open(filepath, FileMode.Open)))
            {
                eskfile.BaseStream.Seek(16, SeekOrigin.Begin);
                int Address = eskfile.ReadInt32();
                eskfile.BaseStream.Seek(Address, SeekOrigin.Begin);
                int BaseAddress = (int)eskfile.BaseStream.Position;
                int boneCount = eskfile.ReadInt16();

                Bones = new eskbone[boneCount];

                eskfile.BaseStream.Seek(2, SeekOrigin.Current);

                int indicesAddress = eskfile.ReadInt32();
                int namesAddress = eskfile.ReadInt32();
                int skinAddress = eskfile.ReadInt32();
                int transformAddress = eskfile.ReadInt32();

                //read indices get parent index
                for (int i = 0; i < boneCount; i++)
                {
                    eskfile.BaseStream.Seek(BaseAddress + indicesAddress + (i * 8), SeekOrigin.Begin);
                    Bones[i].parentIndex = eskfile.ReadInt16();
                }

                //read names
                for (int i = 0; i < boneCount; i++)
                {
                    eskfile.BaseStream.Seek(BaseAddress + namesAddress + i * 4, SeekOrigin.Begin);
                    Address = eskfile.ReadInt32();
                    eskfile.BaseStream.Seek(BaseAddress + Address, SeekOrigin.Begin);
                    byte[] c;
                    string name = "";

                    do
                    {
                        c = eskfile.ReadBytes(1);

                        name += System.Text.Encoding.ASCII.GetString(c);
                    }
                    while (Convert.ToSByte(c[0]) != 0);
                    Bones[i].Name = name;
                }

                //read matrix4x4
                for (int i = 0; i < boneCount; i++)
                {
                    eskfile.BaseStream.Seek(BaseAddress + transformAddress + i * 64, SeekOrigin.Begin);
                    Matrix4x4 boneTransform;
                    boneTransform.m00 = eskfile.ReadSingle();
                    boneTransform.m01 = eskfile.ReadSingle();
                    boneTransform.m02 = eskfile.ReadSingle();
                    boneTransform.m03 = eskfile.ReadSingle();
                    boneTransform.m10 = eskfile.ReadSingle();
                    boneTransform.m11 = eskfile.ReadSingle();
                    boneTransform.m12 = eskfile.ReadSingle();
                    boneTransform.m13 = eskfile.ReadSingle();
                    boneTransform.m20 = eskfile.ReadSingle();
                    boneTransform.m21 = eskfile.ReadSingle();
                    boneTransform.m22 = eskfile.ReadSingle();
                    boneTransform.m23 = eskfile.ReadSingle();
                    boneTransform.m30 = eskfile.ReadSingle();
                    boneTransform.m31 = eskfile.ReadSingle();
                    boneTransform.m32 = eskfile.ReadSingle();
                    boneTransform.m33 = eskfile.ReadSingle();


                    Bones[i].MatrixAddress = (int)(BaseAddress + transformAddress + i * 64);
                    Bones[i].transformData = boneTransform;
                }


            }
        }

        public void WriteEsk()
        {
            using (BinaryWriter eskfile = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < Bones.Length; i++)
                {
                    eskfile.BaseStream.Seek(Bones[i].MatrixAddress, SeekOrigin.Begin);

                    eskfile.Write(Bones[i].transformData.m00);
                    eskfile.Write(Bones[i].transformData.m01);
                    eskfile.Write(Bones[i].transformData.m02);
                    eskfile.Write(Bones[i].transformData.m03);

                    eskfile.Write(Bones[i].transformData.m10);
                    eskfile.Write(Bones[i].transformData.m11);
                    eskfile.Write(Bones[i].transformData.m12);
                    eskfile.Write(Bones[i].transformData.m13);

                    eskfile.Write(Bones[i].transformData.m20);
                    eskfile.Write(Bones[i].transformData.m21);
                    eskfile.Write(Bones[i].transformData.m22);
                    eskfile.Write(Bones[i].transformData.m23);

                    eskfile.Write(Bones[i].transformData.m30);
                    eskfile.Write(Bones[i].transformData.m31);
                    eskfile.Write(Bones[i].transformData.m32);
                    eskfile.Write(Bones[i].transformData.m33);


                }
            }
        }

    }
}
