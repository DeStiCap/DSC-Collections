using Unity.Collections;

namespace DSC.Collections
{
    public struct NativeArray2D<T> : System.IDisposable where T : struct
    {
        #region Variable

        int m_nSizeX;
        int m_nSizeY;

        NativeArray<T> m_narData;

        public bool IsCreated { get { return m_narData.IsCreated; } }
        public int Length { get { return m_narData.Length; } }

        #endregion

        #region Constructor

        public NativeArray2D(T[,] array, Allocator hAllocator)
        {
            int nLength = array.Length;

            m_nSizeX = array.GetLength(0);
            m_nSizeY = array.GetLength(1);

            m_narData = new NativeArray<T>(nLength, hAllocator);

            for (int x = 0; x < m_nSizeX; x++)
            {
                for (int y = 0; y < m_nSizeY; y++)
                {
                    m_narData[x + y * m_nSizeX] = array[x, y];
                }
            }
        }

        public NativeArray2D(int nSizeX, int nSizeY, Allocator hAllocator)
        {
            m_nSizeX = nSizeX;
            m_nSizeY = nSizeY;

            m_narData = new NativeArray<T>(nSizeX * nSizeY, hAllocator);
        }

        #endregion

        #region Interface

        public void Dispose()
        {
            m_narData.Dispose();
        }

        #endregion

        #region Main

        public T this[int x, int y]
        {
            get
            {
                return m_narData[x + y * m_nSizeX];
            }

            set
            {
                m_narData[x + y * m_nSizeX] = value;
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
