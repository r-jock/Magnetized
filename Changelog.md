## Changelog

## [Unreleased]
### Fixed
- 🪙 Coins are now correctly destroyed after reaching the player when magnetized.
- ✅ CircleCollider2D on coins now correctly set to trigger.
- ⚙️ Added minDistance check to prevent lingering coins.

## [0.2.1] – 2025-05-16
### Added
- Magnet System for coins
- Coins move toward player after entering MagnetZone
- XP and Score are added on collection

## [v0.2.0] - 2025-05-16

### Added
- XP and Leveling system with overflow handling
- Level cap set to 30
- Configurable XP scaling multiplier
- UI updates for XP, Level, and Score
- Singleton structure for GameManager

## [0.1.0] - 2025-05-16
### Added
- Basic Player Movement implemented via `PlayerController.cs`
- Rigidbody2D-based physics
- Movement via WASD / Arrow keys
