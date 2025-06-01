
using UnityEngine;

namespace Invector.vCharacterController
{
    public class vThirdPersonAnimator : vThirdPersonMotor
    {

    //Variables...this "#region" command appears to group them together for simplification (I'd assume).
    
    //"Const" sets a variable as a constant, preventing it from being changed.

        #region Variables                

        public const float walkSpeed = 0.5f;
        public const float runningSpeed = 1f;
        public const float sprintSpeed = 1.5f;

        #endregion  


    //This method is for updating the animator...whatever that means.

    //Virtual is used to mark when a method can be overriden by a submethod. I think. 
        public virtual void UpdateAnimator()
        {
            //"||" means OR in an if statement. "Return" means to exit the method early if these conditions are met. 
            if (animator == null || !animator.enabled) return;

            //The variables and methods here are from the "ThirdPersonMotor" script.
            animator.SetBool(vAnimatorParameters.IsStrafing, isStrafing); ;
            animator.SetBool(vAnimatorParameters.IsSprinting, isSprinting);
            animator.SetBool(vAnimatorParameters.IsGrounded, isGrounded);
            animator.SetFloat(vAnimatorParameters.GroundDistance, groundDistance);

            if (isStrafing)
            {
                animator.SetFloat(vAnimatorParameters.InputHorizontal, stopMove ? 0 : horizontalSpeed, strafeSpeed.animationSmooth, Time.deltaTime);
                animator.SetFloat(vAnimatorParameters.InputVertical, stopMove ? 0 : verticalSpeed, strafeSpeed.animationSmooth, Time.deltaTime);
            }
            else
            {
                animator.SetFloat(vAnimatorParameters.InputVertical, stopMove ? 0 : verticalSpeed, freeSpeed.animationSmooth, Time.deltaTime);
            }

            animator.SetFloat(vAnimatorParameters.InputMagnitude, stopMove ? 0f : inputMagnitude, isStrafing ? strafeSpeed.animationSmooth : freeSpeed.animationSmooth, Time.deltaTime);
        }

        public virtual void SetAnimatorMoveSpeed(vMovementSpeed speed)
        {
            Vector3 relativeInput = transform.InverseTransformDirection(moveDirection);
            verticalSpeed = relativeInput.z;
            horizontalSpeed = relativeInput.x;

            var newInput = new Vector2(verticalSpeed, horizontalSpeed);

            if (speed.walkByDefault)
                inputMagnitude = Mathf.Clamp(newInput.magnitude, 0, isSprinting ? runningSpeed : walkSpeed);
            else
                inputMagnitude = Mathf.Clamp(isSprinting ? newInput.magnitude + 0.5f : newInput.magnitude, 0, isSprinting ? sprintSpeed : runningSpeed);
        }
    }


// Stuff for animation, I assume.
    public static partial class vAnimatorParameters
    {
        public static int InputHorizontal = Animator.StringToHash("InputHorizontal");
        public static int InputVertical = Animator.StringToHash("InputVertical");
        public static int InputMagnitude = Animator.StringToHash("InputMagnitude");
        public static int IsGrounded = Animator.StringToHash("IsGrounded");
        public static int IsStrafing = Animator.StringToHash("IsStrafing");
        public static int IsSprinting = Animator.StringToHash("IsSprinting");
        public static int GroundDistance = Animator.StringToHash("GroundDistance");
    }
}