﻿using UnityChess;
using UnityEngine;
using UnityEngine.UI;

public class UnityChessDebug : MonoBehaviourSingleton<UnityChessDebug> {
	[SerializeField] private GameObject debugBoard;

	private void OnEnable() {
		debugBoard.SetActive(true);
	}

	private void Update() {
		UpdateBoardDebugView(GameManager.Instance.CurrentBoard);
	}

	public static void ShowLegalMovesInLog(Piece piece) {
		string debMsg = $"# of valid moves: {piece.ValidMoves.Count}\n";
		foreach (Movement validMove in piece.ValidMoves) {
			debMsg += $"{validMove}\n";
		}
		Debug.LogWarning(debMsg);
	}

	private void UpdateBoardDebugView(Board board) {
		for (int file = 1; file <= 8; file++) {
			for (int rank = 1; rank <= 8; rank++) {
				BasePiece basePiece = board.GetBasePiece(file, rank);
				Text squareText = debugBoard.transform.Find($"{SquareUtil.FileRankToSquareString(file, rank)}").GetComponentInChildren<Text>();

				squareText.text = basePiece is Piece ? basePiece.ToString() : "";
			}
		}
	}
}