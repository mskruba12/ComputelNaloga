using System.Runtime.Serialization;

namespace ComputelNaloga.Models
{
    public enum CarPurpose
    {
        [EnumMember(Value = "MOTO")]
        MOTO,

        [EnumMember(Value = "RV")]
        RV,

        [EnumMember(Value = "NRV")]
        NRV,

        [EnumMember(Value = "REA")]
        REA
    }
}