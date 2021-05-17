using Unity.Collections;

namespace DSC.Collections
{
    public static class Extension_NativeArray
    {
        /// <summary>
        /// Safety dispose native array.
        /// </summary>
        /// <param name="array">Native Array</param>
        /// <typeparam name="T">Data type in array</typeparam>
        public static void DisposeSafety<T>(this NativeArray<T> array) where T : struct
        {
            if(array.IsCreated)
                array.Dispose();
        }
    }
}
