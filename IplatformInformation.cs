namespace CurrentDrives
{
    public interface IplatformInformation
    {
        string BuildsPath { get; set; }

        string Left(this string value, int maxLength);
        void LoadPlatFormTable();
        void ReadPlatFormInformation();
        void WritePlatformInformation();
    }
}