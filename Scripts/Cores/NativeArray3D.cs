using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace DSC.Collections
{
    public struct NativeArray3D<T> : System.IDisposable where T : struct
    {
        #region Variable

        int m_nSizeX;
        int m_nSizeY;
        int m_nSizeZ;

        NativeArray<T> m_narData;

        public bool IsCreated { get { return m_narData.IsCreated; } }

        #endregion

        #region Constructor

        public NativeArray3D(T[,,] array, Allocator hAllocator)
        {
            int nLength = array.Length;

            m_nSizeX = array.GetLength(0);
            m_nSizeY = array.GetLength(1);
            m_nSizeZ = array.GetLength(2);

            m_narData = new NativeArray<T>(nLength, hAllocator);

            for (int x = 0; x < m_nSizeX; x++)
            {
                for (int y = 0; y < m_nSizeY; y++)
                {
                    for (int z = 0; z < m_nSizeZ; z++)
                    {
                        m_narData[x + y * m_nSizeX + z * m_nSizeX * m_nSizeY] = array[x, y, z];
                    }
                }
            }
        }

        public NativeArray3D(int nSizeX, int nSizeY, int nSizeZ, Allocator hAllocator)
        {
            m_nSizeX = nSizeX;
            m_nSizeY = nSizeY;
            m_nSizeZ = nSizeZ;

            m_narData = new NativeArray<T>(nSizeX * nSizeY * nSizeZ, hAllocator);
        }

        #endregion

        #region Interface

        public void Dispose()
        {
            m_narData.Dispose();
        }

        #endregion

        #region Main



        public T this[int x, int y, int z]
        {
            get
            {
                return m_narData[x + y * m_nSizeX + z * m_nSizeX * m_nSizeY];
            }

            set
            {
                m_narData[x + y * m_nSizeX + z * m_nSizeX * m_nSizeY] = value;
            }
        }



        public int GetLength(int dimension)
        {
            switch (dimension)
            {
                case 0:
                    return m_nSizeX;

                case 1:
                    return m_nSizeY;

                case 2:
                    return m_nSizeZ;

                default:
                    return m_nSizeX;
            }
        }

        public NativeArray<T> AsArray1D()
        {
            return m_narData;
        }

        #endregion
    }
}
