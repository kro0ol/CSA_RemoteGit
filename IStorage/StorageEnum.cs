namespace admLab1.Storage
{
    public enum StorageEnum
    {
        Undefined,
        videoCardList,
        FileStorage
    }

    public static class StorageEnumExtensions
    {
        public static StorageEnum ToStorageEnum(this string value)
        {
            switch (value)
            {
                case var s when s.ToLowerInvariant() == "videoCardList"
                                || s.ToLowerInvariant() == "videoCard"
                                || s.ToLowerInvariant() == "CardList":
                    return StorageEnum.videoCardList;
                case var s when s.ToLowerInvariant() == "filestorage"
                                || s.ToLowerInvariant() == "file"
                                || s.ToLowerInvariant() == "storage":
                    return StorageEnum.FileStorage;
                default:
                    return StorageEnum.Undefined;
            }
        }
    }
}