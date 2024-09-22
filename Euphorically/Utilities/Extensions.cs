using System;
using Euphorically.Config;
using GTA;
using GTA.Math;
using GTA.Native;

namespace Euphorically.Utilities
{
    internal static class Extensions
    {
        internal static bool CanPlayerEuphoria(this Player player)
        {
            //TODO: Determine if Euphoria trigger is correct
            Random rnd = new Random();
            
            Configuration config = Configuration.Instance;

            if (player.Character.IsInVehicle() && !Function.Call<bool>(Hash.CAN_KNOCK_PED_OFF_VEHICLE, player))
                return false;
            if (!player.Character.HasBeenDamagedByAnyWeapon() && !player.Character.HasBeenDamagedByAnyMeleeWeapon())
                return false;
            if (config.BaseEuphoriaConfig.BlockEuphoriaWithArmour && player.Character.Armor > 0)
                return false;
            if (!config.BaseEuphoriaConfig.UseRandomEuphoriaChance && rnd.NextDouble() * 100d > config.BaseEuphoriaConfig.BaseEuphoriaChance)
                return false;

            float deltaChance = config.BaseEuphoriaConfig.MaximumEuphoriaChance - config.BaseEuphoriaConfig.MinimumEuphoriaChance;
            double value = config.BaseEuphoriaConfig.MinimumEuphoriaChance + deltaChance * rnd.NextDouble();
            
            return rnd.NextDouble() * 100d < value;
        }

        internal static void ClearLastDamageEntity(this Entity entity)
        {
            Function.Call(Hash.CLEAR_ENTITY_LAST_DAMAGE_ENTITY, entity);
        }

        internal static EuphoriaBones? ConvertToEuphoriaBone(this Bone bone)
        {
            switch (bone)
            {
                case Bone.SkelRoot:
                    return EuphoriaBones.Root;

                #region LeftLeg
                case Bone.SkelLeftThigh:
                    return EuphoriaBones.LeftThigh;
                case Bone.SkelLeftCalf:
                    return EuphoriaBones.LeftCalf;
                case Bone.SkelLeftFoot:
                case Bone.SkelLeftToe0:
                case Bone.SkelLeftToe1:
                    return EuphoriaBones.LeftFoot;
                #endregion
                
                #region RightLeg
                case Bone.SkelRightThigh:
                    return EuphoriaBones.RightThigh;
                case Bone.SkelRightCalf:
                    return EuphoriaBones.RightCalf;
                case Bone.SkelRightFoot:
                case Bone.SkelRightToe0:
                case Bone.SkelRightToe1:
                    return EuphoriaBones.RightFoot;
                #endregion

                #region Torso
                case Bone.SkelPelvis:
                case Bone.SkelPelvis1:
                case Bone.SkelPelvisRoot:
                case Bone.SkelSpineRoot:
                case Bone.SkelSpine0:
                    return EuphoriaBones.Crotch;
                case Bone.SkelSpine1:
                    return EuphoriaBones.LowerStomach;
                case Bone.SkelSpine2: 
                    return EuphoriaBones.Stomach;
                case Bone.SkelSpine3:
                    return EuphoriaBones.Chest;
                #endregion

                #region LeftArm
                case Bone.SkelLeftClavicle:
                    return EuphoriaBones.LeftShoulder;
                case Bone.SkelLeftUpperArm:
                    return EuphoriaBones.LeftUpperArm;
                case Bone.SkelLeftForearm:
                    return EuphoriaBones.LeftForeArm;
                #endregion
                
                #region LeftHand
                case Bone.SkelLeftHand:
                case Bone.SkelLeftFinger00:
                case Bone.SkelLeftFinger01:
                case Bone.SkelLeftFinger02:
                case Bone.SkelLeftFinger10:
                case Bone.SkelLeftFinger11:
                case Bone.SkelLeftFinger12:
                case Bone.SkelLeftFinger20:
                case Bone.SkelLeftFinger21:
                case Bone.SkelLeftFinger22:
                case Bone.SkelLeftFinger30:
                case Bone.SkelLeftFinger31:
                case Bone.SkelLeftFinger32:
                case Bone.SkelLeftFinger40:
                case Bone.SkelLeftFinger41:
                case Bone.SkelLeftFinger42:
                    return EuphoriaBones.LeftHand;
                #endregion

                #region RightArm
                case Bone.SkelRightClavicle:
                    return EuphoriaBones.RightShoulder;
                case Bone.SkelRightUpperArm:
                    return EuphoriaBones.RightUpperArm;
                case Bone.SkelRightForearm:
                    return EuphoriaBones.RightForeArm;
                #endregion
                
                #region RightHand
                case Bone.SkelRightHand:
                case Bone.SkelRightFinger00:
                case Bone.SkelRightFinger01:
                case Bone.SkelRightFinger02:
                case Bone.SkelRightFinger10:
                case Bone.SkelRightFinger11:
                case Bone.SkelRightFinger12:
                case Bone.SkelRightFinger20:
                case Bone.SkelRightFinger21:
                case Bone.SkelRightFinger22:
                case Bone.SkelRightFinger30:
                case Bone.SkelRightFinger31:
                case Bone.SkelRightFinger32:
                case Bone.SkelRightFinger40:
                case Bone.SkelRightFinger41:
                case Bone.SkelRightFinger42:
                    return EuphoriaBones.RightHand;
                #endregion

                #region Head
                case Bone.SkelNeck1:
                    return EuphoriaBones.Neck;
                case Bone.SkelNeck2:
                    return EuphoriaBones.Mouth;
                case Bone.SkelHead:
                    return EuphoriaBones.Eyes;
                #endregion
                
                default:
                    return null;
            }
        }

        internal static Vector3 Abs(this Vector3 v)
        {
            v.X = Math.Abs(v.X);
            v.Y = Math.Abs(v.Y);
            v.Z = Math.Abs(v.Z);

            return v;
        }

        /// <summary>
        /// A clamp function as this version of .NET does not include a Math.Clamp() function.
        /// </summary>
        /// <param name="v">A value to be clamped.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <typeparam name="T">IComparable types</typeparam>
        /// <returns>A value clamped between the min and max, inclusive.</returns>
        /// <remarks>
        /// <see href="https://stackoverflow.com/questions/2683442/where-can-i-find-the-clamp-function-in-net">Implementation Source</see> -
        /// would have implemented something similar but found this whilst searching for Math.Clamp() .NET versions (not 4.8 apparently!).
        /// </remarks>
        internal static T Clamp<T>(this T v, T min, T max) where T : IComparable<T>
        {
            if (v.CompareTo(min) < 0) return min;
            else if (v.CompareTo(max) > 0) return max;
            else return v;
        }
    }
}
