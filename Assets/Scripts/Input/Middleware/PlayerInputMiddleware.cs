using System;
using Input.Data;
using Input.Events;
using Main;

namespace Input.Middleware {
	[Serializable]
	public class PlayerInputMiddleware : InputMiddleware<PlayerInput, PlayerInputEvents.Dispatcher> {
		public override void TransformInput(ref PlayerInput input) {
			input = App.InputManager.PlayerInput;
		}

		public override void Init() {
			App.InputManager.OnInteract += Dispatcher.Interact;
			App.InputManager.OnAttack   += Dispatcher.Attack;
		}

		public override InputMiddleware<PlayerInput, PlayerInputEvents.Dispatcher> Clone() {
			return new PlayerInputMiddleware();
		}
	}
}