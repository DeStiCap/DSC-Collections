using Unity.Collections;

namespace DSC.Collections
{
    public static class Extension_NativeList
    {
        /// <summary>
        /// Safety dispose native list.
        /// </summary>
        /// <param name="array">Native List</param>
        /// <typeparam name="T">Data type in list</typeparam>
        public static void DisposeSafety<T>(this NativeList<T> array) where T : struct
        {
            if(array.IsCreated)
                array.Dispose();
        }
    }
}
