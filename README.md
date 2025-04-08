# Laberinto en C# - Windows Forms

Este es un pequeño juego de laberinto desarrollado en C# con Windows Forms. El jugador debe moverse a través del laberinto evitando obstáculos y alcanzando la meta dentro de un número limitado de turnos.

## 🛠️ Características
- Movimiento continuo hasta chocar con una pared.
- Teletransportación al otro extremo del mapa si se sale de los límites.
- Validación para evitar movimientos inválidos.
- Contador de turnos.
- Mensaje de victoria si se alcanza la meta.
- Mensaje de derrota si se agotan los turnos.

## 🎮 Cómo jugar
1. Usa las teclas de dirección para mover al jugador (`i`).
2. El jugador se mueve en línea recta hasta encontrar una pared (`x`).
3. El objetivo es llegar a la meta (`f`) antes de que se acaben los turnos.
4. Si los turnos llegan a 0, el juego termina con un mensaje de derrota.

## 🔧 Configuración
Para ejecutar el proyecto:
1. Clona este repositorio:
   ```sh
   git clone https://github.com/nanisadw3/Laberinto.git
   ```
2. Ábrelo en Visual Studio.
3. Ejecuta el proyecto.

## 📌 Código Destacado
El método `turno(string seleccion)` gestiona el movimiento del jugador, detecta colisiones con paredes y valida si ha alcanzado la meta o perdido por turnos agotados.

```csharp
private void turno(string seleccion) {
    // Lógica de movimiento del jugador y validaciones
}
```

## ✨ Autor
Este proyecto fue desarrollado por **nanisadw3**. ¡Espero que lo disfrutes!

🚀 ¡Diviértete con el laberinto!

