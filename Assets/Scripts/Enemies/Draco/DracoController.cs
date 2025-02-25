using AI;
using Input.ConcreteInputProviders.Enemy;
using Input.Data.Enemy;
using UnityEngine;

namespace Enemies.Draco {
	[RequireComponent(typeof(Perceptron))]
	[RequireComponent(typeof(EnemyHealthController))]
	public class DracoController : MonoBehaviour {
		public  DracoInputProvider providerTemplate;
		private DracoInputProvider _provider;

		private Perceptron _perceptron;

		private EnemyHealthController _healthController;

		public float speed = 1.0f;

		private void OnEnable() {
			_perceptron = GetComponent<Perceptron>();

			_healthController = GetComponent<EnemyHealthController>();

			_provider = (DracoInputProvider) providerTemplate.Clone(_perceptron);

			_provider.Events.Shoot += () => { Debug.Log($"{this} shoots"); };
		}

		private void FixedUpdate() { HandleInput(_provider.GetInput()); }

		private void HandleInput(DracoInput inputData) {
			transform.position += inputData.Movement * speed;

			if (inputData.LookDir != Quaternion.identity) transform.rotation = inputData.LookDir;
		}
	}
}