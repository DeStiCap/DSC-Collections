namespace DSC.Collections
{
    public static class Extension_NativeArray2D
    {
        /// <summary>
        /// Safety dispose native array.
        /// </summary>
        /// <param name="array">Native Array 2D</param>
        /// <typeparam name="T">Data type in array</typeparam>
        public static void DisposeSafety<T>(this NativeArray2D<T> array) where T : struct
        {
            if(array.IsCreated)
                array.Dispose();
        }
    }
}
