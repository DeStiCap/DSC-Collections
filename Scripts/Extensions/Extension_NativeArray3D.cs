namespace DSC.Collections
{
    public static class Extension_NativeArray3D
    {
        /// <summary>
        /// Safety dispose native array.
        /// </summary>
        /// <param name="array">Native Array 3D</param>
        /// <typeparam name="T">Data type in array</typeparam>
        public static void DisposeSafety<T>(this NativeArray3D<T> array) where T : struct
        {
            if (array.IsCreated)
                array.Dispose();
        }
    }
}
